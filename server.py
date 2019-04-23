import helper
import argparse
import config_helper

from flask import Flask, request, redirect
app = Flask(__name__, template_folder='templates')

configuration = None


def parse_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('-c', '--config-file', required=True, help='Path to configuration file.')
    args = parser.parse_args()
    return args


@app.route('/')
def index():
    return helper.show_page("index")


@app.route('/about')
def about():
    content = {"page_title": "Projekt PERO - O projektu"}
    return helper.show_page("about", content=content)


@app.route('/annotation_servers')
def servers():
    content = {"page_title": "Projekt PERO - Anotační servery"}
    return helper.show_page("servers", content=content)


@app.route('/posts')
def posts():
    content = {"page_title": "Projekt PERO - Všechny příspěvky"}
    return helper.show_page("all_posts", content=content)


@app.route('/datasets')
def datasets():
    content = {"page_title": "Projekt PERO - Datové sady"}
    return helper.show_page("datasets", content=content)


@app.route('/get_handwritten_page', methods=['GET'])
def get_handwritten_page():
    random = int(request.args.get('random'))
    path = configuration["handwritten_dataset"]["source_directory"]
    extensions = configuration["handwritten_dataset"]["source_extensions"]
    return helper.send_file(helper.get_random_file(path, random, extensions), as_attachment=True)


@app.route('/upload_handwritten_pages', methods=['GET', 'POST'])
def upload_handwritten_pages():
    input_name = "uploaded-files"
    path = configuration["handwritten_dataset"]["target_directory"]
    extensions = configuration["handwritten_dataset"]["target_extensions"]

    helper.save_files(request, input_name, path, extensions)
    return redirect("/datasets")


@app.route("/post/<name>")
def show_post(name):
    content = {}
    return helper.show_page(name, content=content, fill_page_title=True)


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
