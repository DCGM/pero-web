import helper

show_project_name=False
show_all_posts_button=True

title = "Projekt PERO <img src='../static/img/brk.png' />"
content = helper.get_posts_preview(helper.sort_posts(helper.get_posts())[:3])
