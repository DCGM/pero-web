import helper
import argparse
import config_helper
import flask
import os

from flask import Flask, request, redirect, render_template_string
app = Flask(__name__)

configuration = None

from jinja2 import Environment, FileSystemLoader

file_loader = FileSystemLoader(
        [os.path.join(os.path.dirname(__file__), "templates"),
         os.path.join(os.path.dirname(__file__), "posts"),
         os.path.join(os.path.dirname(__file__), "")])
env = Environment(loader=file_loader)


def parse_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('-c', '--config-file', required=True, help='Path to configuration file.')
    args = parser.parse_args()
    return args


@app.route('/')
def index():
    posts = helper.get_posts_preview()

    template = env.get_template("static/index.html")
    return template.render({'new_posts': posts})


@app.route('/about')
def about():
    return helper.show_page("static/about.html")


@app.route('/annotation_servers')
def servers():
    return helper.show_page("static/annotation_servers.html")


@app.route('/posts')
def posts():
    posts = helper.get_posts_preview(limit=None)
    template = env.get_template("static/posts.html")
    return template.render({'all_posts': posts})


@app.route('/datasets')
def datasets():
    return helper.show_page("static/datasets.html")


@app.route('/get_handwritten_page', methods=['GET'])
def get_handwritten_page():
    path = configuration["handwritten_dataset"]["source_directory"]
    extensions = configuration["handwritten_dataset"]["source_extensions"]
    return helper.send_file(helper.get_random_file(path, extensions), as_attachment=True)


@app.route('/upload_handwritten_pages', methods=['GET', 'POST'])
def upload_handwritten_pages():
    input_name = "uploaded-files"
    path = configuration["handwritten_dataset"]["target_directory"]
    extensions = configuration["handwritten_dataset"]["target_extensions"]

    helper.save_files(request, input_name, path, extensions)
    return redirect("/datasets")


@app.route("/post/<name>")
def show_post(name):
    return helper.show_page(name + ".html")


def main():
    args = parse_args()

    global configuration
    configuration = config_helper.parse_configuration(args.config_file)

    host = configuration["common"]["host"]
    port = configuration["common"]["port"]
    debug = configuration["common"]["debug"]
    app.run(host=host, port=port, debug=debug)


if __name__ == '__main__':
    main()
