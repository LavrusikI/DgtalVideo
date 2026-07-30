document.addEventListener('DOMContentLoaded', function () {
    function setFormVisible(form, toggleBtn, visible) {
        if (!form || !toggleBtn) {
            return;
        }

        form.classList.toggle('is-hidden', !visible);
        toggleBtn.setAttribute('aria-expanded', visible ? 'true' : 'false');
        toggleBtn.classList.toggle('is-active', visible);
    }

    function wireToggle(toggleId, formId) {
        const toggleBtn = document.getElementById(toggleId);
        const form = document.getElementById(formId);

        if (!toggleBtn || !form) {
            return;
        }

        toggleBtn.addEventListener('click', function () {
            const willOpen = form.classList.contains('is-hidden');
            setFormVisible(form, toggleBtn, willOpen);
            if (willOpen) {
                const firstInput = form.querySelector('input, textarea');
                if (firstInput) {
                    firstInput.focus();
                }
            }
        });
    }

    wireToggle('togglePortfolioForm', 'portfolioCreateForm');
    wireToggle('toggleReviewForm', 'reviewCreateForm');

    document.querySelectorAll('[data-close-form]').forEach(function (btn) {
        btn.addEventListener('click', function () {
            const form = document.getElementById(btn.getAttribute('data-close-form'));
            const toggleBtn = document.getElementById(btn.getAttribute('data-toggle-btn'));
            setFormVisible(form, toggleBtn, false);
        });
    });
});
