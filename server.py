import os
import helper

from flask import Flask, request, redirect
app = Flask(__name__, template_folder='templates')


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
    path = "/mnt/matylda1/hradis/PERO/brno_hwr_dataset/texts/"
    extensions = ("jpg", "png", "pdf")
    return helper.send_file(helper.get_random_file(path, random, extensions), as_attachment=True)


@app.route('/upload_handwritten_pages', methods=['GET', 'POST'])
def upload_handwritten_pages():
    input_name = "uploaded-files"
    path = "/tmp/flask_upload/"
    extensions = ("jpg", "png", "pdf")

    helper.save_files(request, input_name, path, extensions)
    return redirect("/datasets")


@app.route("/post/<name>")
def show_post(name):
    content = {}
    return helper.show_page(name, content=content, fill_page_title=True)


if __name__ == '__main__':
    host = '127.0.0.1'
    port = 8080
    debug = False

    app.run(host=host, port=port, debug=debug)
