import re
import os
import sys
import random
import hashlib
import datetime
import subprocess
import json

import language_helper

from typing import Optional
from bmod.result import Result, Status
from bmod.eval_result import EvaluationResult

from flask import render_template, send_file
from werkzeug.utils import secure_filename

from jinja2 import Environment, FileSystemLoader, BaseLoader, Template

file_loader = FileSystemLoader(
        [os.path.join(os.path.dirname(__file__), "templates"),
         os.path.join(os.path.dirname(__file__), "posts"),
         os.path.join(os.path.dirname(__file__), "")])
env = Environment(loader=file_loader)


POST_FILE_PATTERN = "^\d{4}\-\d{2}-\d{2}_[\S\s]+\.html.(en|cs)$"


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


def save_files(request, language, input_name, path, extensions):
    create_dirs(path)

    success = True

    extensions_error_printed = False

    status = Status.FAILURE
    message = language_helper.texts[language_helper.Message.save_files_failure][language]

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
                    message += " {allowed_extensions}: {extensions}.".format(allowed_extensions=language_helper.texts[language_helper.Message.allowed_extensions][language], extensions=", ".join(extensions))
                    extensions_error_printed = True

    if success:
        status = Status.SUCCESS
        message = language_helper.texts[language_helper.Message.files_saved_successfully][language]

    return Result(status, None, message)


def show_page(page, language, *args, **kwargs):
    path = localize_path(page, language)

    if path is None:
        not_found_path = localize_path("static/not_found.html", language)
        if not_found_path is None:
            return None
        else:
            path = not_found_path

    template = env.get_template(path)
    return template.render(*args, **kwargs)


def localize_path(page, language):
    path = None

    localized_path = "{page}.{lang}".format(page=page, lang=language_helper.Language.to_string(language))
    english_path = "{page}.{lang}".format(page=page, lang=language_helper.Language.to_string(language_helper.Language.english))
    original_path = page

    if os.path.isfile(localized_path):
        path = localized_path
    elif os.path.isfile(english_path):
        path = english_path
    elif os.path.isfile(original_path):
        path = original_path

    return path


def sort_posts(posts):
    return sorted(posts, reverse=True)


def get_bmod_page(evaluation_results, result: Optional[Result] = None, path="pages/brno_mobile_ocr_dataset.html", language=language_helper.Language.english):
    if result is not None:
        if result.status == Status.SUCCESS:
            output = show_page(path, language=language, success=True, message=result.message, evaluation_results=evaluation_results)
        else:
            output = show_page(path, language=language, success=False, message=result.message, evaluation_results=evaluation_results)
    else:
        output = show_page(path, language=language, evaluation_results=evaluation_results)

    return output


def get_hwr_page(result: Optional[Result] = None, path="pages/handwritten_dataset.html", language=language_helper.Language.english):
    if result is not None:
        if result.status == Status.SUCCESS:
            output = show_page(path, language=language, success=True, message=result.message)
        else:
            output = show_page(path, language=language, success=False, message=result.message)
    else:
        output = show_page(path, language=language)

    return output


def get_posts_preview(limit=3, sort=True, language=language_helper.Language.english):
    posts = get_all_posts(language=language)

    if sort:
        posts = sort_posts(posts)

    if limit is not None:
        posts = posts[:limit]

    return render_posts_preview(posts)


def get_all_posts(path="posts", language=language_helper.Language.english):
    all_posts = [f for f in os.listdir(path) if is_post_file(f)]
    all_posts_set = set([post.rsplit(".", maxsplit=1)[0] for post in all_posts])

    return filter(None, [localize_path(path + "/" + post, language) for post in all_posts_set])


def is_post_file(filename):
    if re.match(POST_FILE_PATTERN, filename):
        return True

    return False


def render_posts_preview(posts):
    previews = []

    for post in posts:
        post_content = ""
        with open(post, "r") as f:
            for line in f:
                line = re.sub(r"{%\s*extends\s+.+?\s*%}", "{% extends 'post_preview.html' %}", line)
                post_content += line

        file_name_without_extension = os.path.basename(post).split(".")[0]
        post_link = "post/{name}".format(name=file_name_without_extension)

        preview = env.from_string(post_content)
        previews.append(preview.render(link=post_link))

    return "<hr>".join(previews)


def get_language(ip):
    location = subprocess.check_output('curl http://ip-api.com/json/' + ip, shell=True)
    country = json.loads(location.decode('ascii'))["countryCode"]
    return language_helper.Language.from_string(country)
