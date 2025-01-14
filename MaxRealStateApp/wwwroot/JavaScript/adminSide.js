var BaseURl = localStorage.getItem("BASEURL");

function AgentProfile() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#Profile")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#proFilePath").val(cv);
        }
    });
}

function UploadPicOne() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#picOne")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#hpicOne").val(cv);
        }
    });
}

function UploadPicTwo() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#picTwo")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#hpicTwo").val(cv);
        }
    });
}
function UploadPicThree() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#picThree")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#hpicThree").val(cv);
        }
    });
}
function uploadBlogPone() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#picOneB")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#PictureOne").val(cv);
        }
    });
}
function uploadBlogPtwo() {
    debugger;
    var formData = new FormData();
    formData.append('file', $("#picTwoB")[0].files[0]);

    $.ajax({
        url: BaseURl + '/api/UploadFile',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            debugger;
            var cv = data.data; // Assuming 'data.data' is the path or value you want to insert
            $("#PictureTwo").val(cv);
        }
    });
}



function openEditModal(item) {
    // Parse item details and populate modal fields
    document.getElementById("agentId").value = item.Id || "";
    document.getElementById("agentName").value = item.Name || "";
    document.getElementById("agentEmail").value = item.Email || "";
    document.getElementById("agentPhone").value = item.Phone || "";
    document.getElementById("agentAddress").value = item.Address || "";
    document.getElementById("agentDepartment").value = item.Department || "";

    // Show the modal
    let modal = new bootstrap.Modal(document.getElementById("addOrderModal"));
    modal.show();
}



let editorInstance;

// Initialize CKEditor
ClassicEditor
    .create(document.querySelector('#editor'), {
        toolbar: [
            'heading', '|',
            'bold', 'italic', 'link', 'bulletedList', 'numberedList', '|',
            'imageUpload', 'blockQuote', 'undo', 'redo'
        ],
        image: {
            toolbar: [
                'imageTextAlternative', 'imageStyle:full', 'imageStyle:side'
            ]
        }
    })
    .then(editor => {
        editorInstance = editor;

        // Intercept image uploads
        editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
            return new MyUploadAdapter(loader);
        };
    })
    .catch(error => {
        console.error(error);
    });

// Custom Upload Adapter
class MyUploadAdapter {
    constructor(loader) {
        this.loader = loader;
    }

    upload() {
        return this.loader.file
            .then(file => {
                return new Promise((resolve, reject) => {
                    const formData = new FormData();
                    formData.append('file', file);

                    $.ajax({
                        url: BaseURl + '/api/UploadFile',
                        type: 'POST',
                        data: formData,
                        processData: false,
                        contentType: false,
                        success: function (data) {
                            debugger;
                            resolve({
                                default: BaseURl + "/UploadedFiles/" + data.data 
                            });
                        }
                    });
                });
            });
    }

    abort() {
        // Abort the upload process
    }
}


function EditPropertyModel(data) {
    

    // Populate modal fields
    document.getElementById('propertyId').value = data.Id || '';
    document.getElementById('PropertyName').value = data.PropertyName || '';
    document.getElementById('propertyType').value = data.PropertyType || '';
    document.getElementById('CommercialType').value = data.CommercialType || '';
    document.getElementById('ResidentType').value = data.ResidentType || '';
    document.getElementById('Purpose').value = data.Purpose || '';
    document.getElementById('SqFt').value = data.SqFt || '';
    document.getElementById('TotalBedroom').value = data.TotalBedroom || '';
    document.getElementById('TotalBath').value = data.TotalBath || '';
    document.getElementById('hpicOne').value = data.Pic1 || '';
    document.getElementById('hpicTwo').value = data.Pic2 || '';
    document.getElementById('hpicThree').value = data.Pic3 || '';
    document.getElementById('Price').value = data.Price || '';
    // Update CKEditor content with raw HTML
    if (editorInstance) {
        editorInstance.setData(data.Description || '');  // Set the raw HTML content into CKEditor
    }
    document.getElementById('Country').value = data.Country || '';
    document.getElementById('City').value = data.City || '';
    document.getElementById('Area').value = data.Area || '';
    document.getElementById('Address').value = data.Address || '';
    document.getElementById('OwnerName').value = data.OwnerName || '';
    document.getElementById('OwnerAddress').value = data.OwnerAddress || '';
    document.getElementById('OwnerPhoneNumber').value = data.OwnerPhoneNumber || '';
    document.getElementById('AgentId').value = data.AgentId || '';
   

    // Open the modal
    const modal = new bootstrap.Modal(document.querySelector('.propertyModel'));
    modal.show();
}

function EditBlogModel(data) {
    // Populate the input fields
    document.getElementById('Id').value = data.Id || '';
    document.getElementById('Title').value = data.Title || '';
    document.getElementById('CreatedUser').value = data.CreatedUser || '';
    document.getElementById('PictureOne').value = data.PictureOne || '';
    document.getElementById('PictureTwo').value = data.PictureTwo || '';

    // Update CKEditor content with the blog description
    if (editorInstance) {
        editorInstance.setData(data.Description || '');  // Use raw HTML data for CKEditor
    }

    // Open the modal
    const modal = new bootstrap.Modal(document.querySelector('.blogModel'));
    modal.show();
}

