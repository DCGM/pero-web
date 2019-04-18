import helper

from flask import Flask
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


@app.route("/post/<name>")
def show_post(name):
    content = {}
    return helper.show_page(name, content=content, fill_page_title=True)


if __name__ == '__main__':
    host = '0.0.0.0'
    port = 8080
    debug = False

    app.run(host=host, port=port, debug=debug)
