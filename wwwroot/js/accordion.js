document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.accordion-item').forEach(function (item) {
        const trigger = item.querySelector('.accordion-trigger');
        const panel = item.querySelector('.accordion-panel');

        if (!trigger || !panel) {
            return;
        }

        trigger.setAttribute('aria-expanded', 'false');

        trigger.addEventListener('click', function () {
            const isOpen = trigger.classList.contains('active');

            document.querySelectorAll('.accordion-trigger.active').forEach(function (t) {
                t.classList.remove('active');
                t.setAttribute('aria-expanded', 'false');
            });
            document.querySelectorAll('.accordion-panel.is-open').forEach(function (p) {
                p.classList.remove('is-open');
            });

            if (!isOpen) {
                trigger.classList.add('active');
                panel.classList.add('is-open');
                trigger.setAttribute('aria-expanded', 'true');
            }
        });
    });
});
