document.addEventListener('DOMContentLoaded', function () {
    const toggle = document.getElementById('menuToggle');
    const nav = document.getElementById('siteNav');

    if (toggle && nav) {
        toggle.addEventListener('click', function () {
            nav.classList.toggle('site-nav--open');
        });
    }
});
