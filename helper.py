import re
import os
import sys
import random
import hashlib
import datetime

from typing import Optional
from bmod.result import Result, Status

from flask import render_template, send_file
from werkzeug.utils import secure_filename

from jinja2 import Environment, FileSystemLoader, BaseLoader, Template

file_loader = FileSystemLoader(
        [os.path.join(os.path.dirname(__file__), "templates"),
         os.path.join(os.path.dirname(__file__), "posts"),
         os.path.join(os.path.dirname(__file__), "")])
env = Environment(loader=file_loader)


POST_FILE_PATTERN = "\d{4}\-\d{2}-\d{2}_[\S\s]+\.html"


def get_random_file(dir_path, extensions):
    files = [f for f in os.listdir(dir_path) if f.lower().endswith(extensions)]
    random.seed()
    random_number = random.randint(0, len(files))
    file = files[random_number]
    return os.path.join(dir_path, file)


def enrich_filename(filename):
    suffix = hashlib.sha512((str(datetime.datetime.now()) + str(random.randint(0, sys.maxsize))).encode()).hexdigest()
    parts = filename.split(".")

    parts.insert(len(parts) - 1, suffix)
    result = ".".join(parts)

    return result


def is_allowed(file, extensions):
    if str(file.filename).lower().endswith(extensions):
        return True

    return False


def create_dirs(path):
    if not os.path.exists(path):
        os.makedirs(path)


def save_files(request, input_name, path, extensions):
    create_dirs(path)

    success = True

    extensions_error_printed = False

    status = Status.FAILURE
    message = "There was a problem saving your file(s)."

    if input_name in request.files:
        files = request.files.getlist(input_name)

        for file in files:
            if file.filename != '' and is_allowed(file, extensions):
                filename = secure_filename(file.filename)
                filename = enrich_filename(filename)

                file_path = os.path.join(path, filename)

                file.save(file_path)
                if not os.path.isfile(file_path):
                    success = False
            else:
                success = False

                if not is_allowed(file, extensions) and not extensions_error_printed:
                    message += " Allowed extensions: " + ", ".join(extensions) + "."

    if success:
        status = Status.SUCCESS
        message = "File(s) successfully saved. Thank you for participating."

    return Result(status, None, message)


def show_page(page, *args, **kwargs):
    template = env.get_template(page)
    return template.render(*args, **kwargs)


def sort_posts(posts):
    return sorted(posts, reverse=True)


def get_bmod_page(result: Optional[Result] = None, path="static/brno_mobile_ocr_dataset.html", ):
    if result is not None:
        if result.status == Status.SUCCESS:
            eval_data = result.data
            output = show_page(path, success=True, id=eval_data.id, cer=eval_data.cer, wer=eval_data.wer, message=result.message)
        else:
            output = show_page(path, success=False, message=result.message)
    else:
        output = show_page(path)

    return output


def get_hwr_page(result: Optional[Result] = None, path="static/handwritten_dataset.html"):
    if result is not None:
        if result.status == Status.SUCCESS:
            output = show_page(path, success=True, message=result.message)
        else:
            output = show_page(path, success=False, message=result.message)
    else:
        output = show_page(path)

    return output


def get_posts_preview(limit=3, sort=True):
    posts = get_all_posts()

    if sort:
        posts = sort_posts(posts)

    if limit is not None:
        posts = posts[:limit]

    return render_posts_preview(posts)


def get_all_posts(path="posts"):
    return [f for f in os.listdir(path) if is_post_file(f)]


def is_post_file(filename):
    if re.match(POST_FILE_PATTERN, filename):
        return True

    return False


def render_posts_preview(posts):
    previews = []

    for post in posts:
        post_content = ""
        with open("posts/" + post, "r") as f:
            for line in f:
                line = re.sub(r"{%\s*extends\s+.+?\s*%}", "{% extends 'post_preview.html' %}", line)
                post_content += line

        post_link = "post/{name}".format(name=post.rsplit(".", maxsplit=1)[0])

        preview = env.from_string(post_content)
        previews.append(preview.render(link=post_link))

    return "<hr>".join(previews)
