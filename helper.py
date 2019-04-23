import re
import os
import sys
import random
from flask import render_template, send_file

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


def get_random_file(dir_path, random_number):
    files = os.listdir(dir_path)
    file = files[random_number % len(files)]
    return os.path.join(dir_path, file)


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
