function getInitials(name) {
    if (!name) {
        return '';
    }

    const words = name.trim().split(/\s+/).filter(Boolean);
    if (words.length === 0) {
        return '';
    }

    const initials = words.length > 1
        ? words[0][0] + words[words.length - 1][0]
        : words[0][0];

    return initials.toUpperCase();
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.review-card__avatar[data-name]').forEach(function (avatar) {
        avatar.textContent = getInitials(avatar.getAttribute('data-name'));
    });
});
