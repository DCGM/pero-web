import helper

title = "Všechny příspěvky"
content = helper.get_posts_preview(helper.sort_posts(helper.get_posts()))
