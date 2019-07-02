import helper
import argparse
import config_helper
import flask
import os

from flask import Flask, request, redirect, render_template_string
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


@app.route('/publications')
def publications():
    return helper.show_page("static/publications.html")


@app.route('/datasets')
def datasets():
    return helper.show_page("static/datasets.html")


@app.route('/brno_mobile_ocr_dataset', methods=['GET', 'POST'])
def brno_mobile_ocr_dataset():
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
            result = Result(Status.FAILURE, None, "Leaderboard already contains results for given combination of name ({name}) and description ({description}). Please use different combination.".format(name=name, description=description))

        output = helper.get_bmod_page(evaluation_results=evaluation_results, result=result)
    else:
        output = helper.get_bmod_page(evaluation_results=evaluation_results)

    return output


@app.route('/brno_mobile_ocr_dataset/bmod_lines.zip')
def bmod_lines():
    return helper.send_file(configuration["brno_mobile_ocr_dataset"]["bmod_lines_zip"], as_attachment=True)


@app.route('/get_handwritten_page', methods=['GET'])
def get_handwritten_page():
    path = configuration["handwritten_dataset"]["source_directory"]
    extensions = configuration["handwritten_dataset"]["source_extensions"]
    return helper.send_file(helper.get_random_file(path, extensions), as_attachment=True)


@app.route('/handwritten_dataset', methods=['GET', 'POST'])
def upload_handwritten_pages():
    if request.method == 'POST':
        input_name = "hwr_uploaded_files"

        try:
            path = configuration["handwritten_dataset"]["target_directory"]
            extensions = configuration["handwritten_dataset"]["target_extensions"]
            configuration_success = True
        except:
            result = Result(Status.FAILURE, None, "There is a problem with server configuration.")
            configuration_success = False

        if configuration_success:
            try:
                result = helper.save_files(request, input_name, path, extensions)
            except:
                result = Result(Status.FAILURE, None, "There was a problem saving your file(s).")

        output = helper.get_hwr_page(result)
    else:
        output = helper.get_hwr_page()

    return output


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
