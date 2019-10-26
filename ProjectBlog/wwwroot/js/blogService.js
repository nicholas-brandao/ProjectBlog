define(['./template.js', '../lib/showdown/showdown.js'], function (template, showdown) {
    var blogPostLatest = '/Home/GetBlogPostsLatest';
    var blogPostUrl = '/Home/Post/?link=';
    var blogMorePostsUrl ='/Home/MoreBlogPosts/?oldestBlogPostId=';
    var oldestBlogPostId = 0;

    function setOldestBlogPostId(data) {
        var ids = data.map(item => item.id);
        oldestBlogPostId = Math.min(...ids);
    }

    function getBlogPostsLatest() {
        loadData(blogPostLatest);
    }

    function getMoreBlogPosts() {
        loadData(blogMorePostsUrl + oldestBlogPostId);
    }

    function getBlogPost(link) {
        fetch(blogPostUrl + link)
            .then(function (response) {
                return response.text();
            }).then(function (data) {
                var converter = new showdown.Converter();
                html = converter.makeHtml(data);
                template.showBlogItem(html, link);
                window.location = '#' + link;
            });
    }    function loadData(url) {
        fetch(url)
            .then(function (response) {
                return response.json();
            }).then(function (data) {
                console.log(data);
                template.appendBlogList(data);
                setOldestBlogPostId(data);
            });
    }    

    return {
        getBlogPostsLatest: getBlogPostsLatest,
        getBlogPost: getBlogPost,
        getMoreBlogPosts: getMoreBlogPosts
    }
});