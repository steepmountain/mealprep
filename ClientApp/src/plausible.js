export default {
    install(vue, domain, disable = false) {
        if (!document || disable || !domain) return

        (function (w, d, s, o, f, js, fjs) {
            w[o] = w[o] || function () {
                (w[o].q = w[o].q || []).push(arguments)
            };
            js = d.createElement(s), fjs = d.getElementsByTagName(s)[0];
            js.id = o;
            js.src = f;
            js.setAttribute('data-domain', domain);
            js.async = 1;
            fjs.parentNode.insertBefore(js, fjs);
        }(window, document, 'script', 'plausible', 'https://plausible.io/js/p.js'))

        window.plausible('page')
        window.plausible('trackPushState')
    }
}