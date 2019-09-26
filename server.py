import requests

import helper
import argparse
import config_helper
import flask
import os

import language_helper
import subprocess
import json

from flask import Flask, request, redirect, render_template_string, url_for
from bmod import helper as bmod_helper
from bmod.result import  Result, Status
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


@app.errorhandler(404)
def page_not_found(e):
    return redirect("/not_found", code=302)


@app.route('/not_found')
def not_found():
    return create_response("pages/not_found.html")


@app.route('/')
def index():
    language = get_language()
    posts = helper.get_posts_preview(language=language)

    path = helper.localize_path("pages/index.html", language)

    template = env.get_template(path)
    return template.render({'new_posts': posts})


@app.route('/about')
def about():
    return create_response("pages/about.html")


@app.route('/posts')
def posts():
    language = get_language()
    posts = helper.get_posts_preview(limit=None, language=language)

    path = helper.localize_path("pages/posts.html", language)

    template = env.get_template(path)
    return template.render({'all_posts': posts})


@app.route('/publications')
def publications():
    return create_response("pages/publications.html")


@app.route('/datasets')
def datasets():
    return create_response("pages/datasets.html")


@app.route('/brno_mobile_ocr_dataset', methods=['GET', 'POST'])
def brno_mobile_ocr_dataset():
    language = get_language()

    response = flask.make_response(brno_mobile_ocr_page(language=language))

    set_language_cookie(response, language)

    return response


def brno_mobile_ocr_page(language=language_helper.Language.english):
    evaluation_results = bmod_helper.parse_results(configuration["brno_mobile_ocr_dataset"]["result_data"])

    if request.method == 'POST':
        name = request.form["bmod_upload_name"]
        description = request.form["bmod_upload_description"]

        if bmod_helper.check_name(evaluation_results, name, description):
            file_path = bmod_helper.save_file(request, name, description, "bmod_uploaded_transcription_file", configuration["brno_mobile_ocr_dataset"]["upload_path"], configuration["brno_mobile_ocr_dataset"]["translation_file"])
            bmod_helper.write_results_file(name, description, configuration["brno_mobile_ocr_dataset"]["result_data"])

            if file_path is not None:
                result = Result(Status.SUCCESS, None, "Thank you for your participation. Your results will be calculated and published within few minitues in the table below.")
            else:
                result = Result(Status.FAILURE, None, "Could not save file from the request.")
        else:
            result = Result(Status.FAILURE, None, "Leaderboard already contains results for given name ({name}). Please use different name.".format(name=name, description=description))
    else:
        result = None

    output = helper.get_bmod_page(evaluation_results=evaluation_results, path="pages/brno_mobile_ocr_dataset.html", result=result, language=language)

    return output


@app.route('/get_handwritten_page', methods=['GET'])
def get_handwritten_page():
    path = configuration["handwritten_dataset"]["source_directory"]
    extensions = configuration["handwritten_dataset"]["source_extensions"]
    return helper.send_file(helper.get_random_file(path, extensions), as_attachment=True)


@app.route('/handwritten_dataset', methods=['GET', 'POST'])
def handwritten_dataset():
    language = get_language()

    response = flask.make_response(handwritten_page(language=language))
    set_language_cookie(response, language)

    return response


def handwritten_page(language=language_helper.Language.english):
    if request.method == 'POST':
        input_name = "hwr_uploaded_files"

        try:
            path = configuration["handwritten_dataset"]["target_directory"]
            extensions = configuration["handwritten_dataset"]["target_extensions"]
            configuration_success = True
        except:
            result = Result(Status.FAILURE, None, language_helper.texts[language_helper.Message.server_config_failure][language])
            configuration_success = False

        if configuration_success:
            try:
                result = helper.save_files(request, language, input_name, path, extensions)
            except:
                result = Result(Status.FAILURE, None, language_helper.texts[language_helper.Message.save_files_failure][language])

    else:
        result = None

    output = helper.get_hwr_page(result=result, path="pages/handwritten_dataset.html", language=language)

    return output


@app.route("/post/<name>")
def show_post(name):
    return create_response("posts/" + name + ".html")


def get_language():
    if 'pero_language' in request.cookies:
        language = language_helper.Language.from_string(request.cookies.get('pero_language'))
    else:
        language = language_helper.Language.english
#        try:
#            language = helper.get_language(request.remote_addr)
#        except:
#            language = language_helper.Language.english

    return language


def set_language_cookie(response, language):
    response.set_cookie('pero_language', language_helper.Language.to_string(language))


def create_response(path):
    language = get_language()

    response = flask.make_response(helper.show_page(path, language))
    set_language_cookie(response, language)

    return response


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
