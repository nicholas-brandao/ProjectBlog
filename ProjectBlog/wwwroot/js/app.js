
var blogService = require('./blogService.js');

blogService.getBlogPostsLatest();

window.pageEvents = {
    getBlogPost: function (link) {
        blogService.getBlogPost(link);
    }    ,    getMoreBlogPosts: function () {
        blogService.getMoreBlogPosts();
    }}