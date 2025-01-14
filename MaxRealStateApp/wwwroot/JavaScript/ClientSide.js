function selectCategory(category) {
    // Hide the main dropdown
    document.getElementById('category-dropdown').style.display = 'none';

    // Show the selected category with close button
    const selectedCategory = document.getElementById('selected-category');
    selectedCategory.style.display = 'flex';
    document.getElementById('selected-text').innerText = category;

    // Hide all submenus initially
    document.getElementById('commercial-submenu').style.display = 'none';
    document.getElementById('residential-submenu').style.display = 'none';

    // Show the appropriate submenu based on category
    if (category === 'Commercial') {
        document.getElementById('commercial-submenu').style.display = 'flex';
    } else if (category === 'Residential') {
        document.getElementById('residential-submenu').style.display = 'flex';
    }
}

function resetCategory() {
    // Show the main dropdown
    document.getElementById('category-dropdown').style.display = 'inline-block';

    // Hide the selected category and submenus
    document.getElementById('selected-category').style.display = 'none';
    document.getElementById('commercial-submenu').style.display = 'none';
    document.getElementById('residential-submenu').style.display = 'none';
}

function toggleDropdown() {
    const dropdownContent = document.querySelector('.dropdown-content');
    const display = dropdownContent.style.display;

    if (display === 'none' || display === '') {
        dropdownContent.style.display = 'block';
    } else {
        dropdownContent.style.display = 'none';
    }
}

window.addEventListener('scroll', function () {
    const siteNav = document.getElementById('siteNav');
    const headerContainer = document.getElementById('headerContainer');

    if (window.scrollY > 50) {
        siteNav.classList.add('sticky');
    } else {
        siteNav.classList.remove('sticky');
    }
});

function gridProfile() {
    // Show grid view and hide card view
    document.getElementById("gridProfile").style.display = "block";
    document.getElementById("cardProfile").style.display = "none";

    // Update active state for buttons
    document.getElementById("gridbtn").querySelector('.toggle-btn').classList.add("active");
    document.getElementById("cardbtn").querySelector('.toggle-btn').classList.remove("active");
}

function cardProfile() {
    // Show card view and hide grid view
    document.getElementById("gridProfile").style.display = "none";
    document.getElementById("cardProfile").style.display = "block";

    // Update active state for buttons
    document.getElementById("cardbtn").querySelector('.toggle-btn').classList.add("active");
    document.getElementById("gridbtn").querySelector('.toggle-btn').classList.remove("active");
}

document.addEventListener("DOMContentLoaded", function () {
    // Default view set to Grid on page load
    gridProfile();
});