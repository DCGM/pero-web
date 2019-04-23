import re
import os
import sys
import random
import hashlib
import datetime
from flask import render_template, send_file
from werkzeug.utils import secure_filename

sys.path.append("posts")

CONTENT_FILE_PATTERN = r"^\[[a-zA-Z0-9\s_\\.\-\(\):]+(\.html)\]$"


def get_value(config, attribute, default=None):
    return getattr(config, attribute, default)


def fill_content(content, config):
    props = ([item for item in dir(config) if not item.startswith("__")])
    for prop in props:
        if prop not in content:
            content[prop] = get_value(config, prop)


def fill_default(context, prop, value):
    if prop not in context:
        context[prop] = value


def fill_defaults(context):
    fill_default(context, "show_all_posts_button", False)
    fill_default(context, "show_project_name", True)


def get_random_file(dir_path, random_number, extensions):
    files = [f for f in os.listdir(dir_path) if f.lower().endswith(extensions)]
    file = files[random_number % len(files)]
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

    if input_name in request.files:
        files = request.files.getlist(input_name)

        for file in files:
            if file.filename != '' and is_allowed(file, extensions):
                filename = secure_filename(file.filename)
                filename = enrich_filename(filename)
                file.save(os.path.join(path, filename))


def load_content_file(name):
    path = "static/content/{name}".format(name=name[1:-1])
    content = "Nebylo možné nalézt soubor {path}".format(path=path)
    if os.path.isfile(path):
        with open(path, "r") as f:
            content = f.read()

    return content


def show_page(page, content=None, fill_page_title=False):
    post = __import__(page)

    if content is None:
        content = {}

    fill_content(content, post)
    fill_defaults(content)

    if fill_page_title:
        content["page_title"] = "Projekt PERO - {post_name}".format(post_name=content["title"])

    if re.match(CONTENT_FILE_PATTERN, content["content"]) is not None:
        content["content"] = load_content_file(content["content"])

    return render_template('template.html', property=content)


def get_posts(path="posts"):
    return [os.path.splitext(f)[0] for f in os.listdir(path) if
            f != os.path.basename(__file__) and f != "README.txt" and not f.startswith("__")]


def sort_posts(posts):
    posts_with_times = []

    for post in posts:
        content = {}
        fill_content(content, __import__(post))

        if "created" in content:
            posts_with_times.append((post, content["created"]))

    sorted_posts = sorted(posts_with_times, key=lambda p: p[1], reverse=True)

    return [post[0] for post in sorted_posts]


def get_posts_preview(posts):
    previews = []

    for post in posts:
        content = {"link": "/post/{post_name}".format(post_name=post)}
        fill_content(content, __import__(post))

        preview = render_template('post_preview.html', property=content)
        previews.append(preview)

    return "<hr>".join(previews)
