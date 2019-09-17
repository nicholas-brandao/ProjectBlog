define([], function () {
    var blogPostUrl = "/Home/GetBlogPostsLatest/";

    function getBlogPostsLatest() {
        fecth(blogPostUrl)
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                console.log(data);
            })
    }

    return {
        getBlogPostsLatest: getBlogPostsLatest
    }
});