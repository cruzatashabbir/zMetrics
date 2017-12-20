// FORM VALIDATION CUSTOM ERROR CONTAINER
// =================================================================
// Indicate where the error messages are shown.
// Tooltip, Popover, Custom Container.
// =================================================================


$(document).ready(function(){

    $('#loginForm').bootstrapValidator({
        message: 'This value is not valid',
        excluded: [':disabled'],
        //feedbackIcons: faIcon,
        fields: {
            username: {
                container: '#demo-error-container',
                message: 'The username is not valid',
                validators: {
                    notEmpty: {
                        message: 'The username is required and cannot be empty'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    },
                    //regexp: {
                    //    regexp: /^[a-zA-Z0-9_\.]+$/,
                    //    message: 'The username can only consist of alphabetical, number, dot and underscore'
                    //},
                    different: {
                        field: 'password',
                        message: 'The username and password cannot be the same as each other'
                    }
                }
            },
            password: {
                container: '#demo-error-container',
                validators: {
                    notEmpty: {
                        message: 'The password is required and cannot be empty'
                    },
                    stringLength: {
                        min: 6,
                        max: 20,
                        message: 'The password must be more than 6 and less than 20 characters long'
                    },
                    different: {
                        field: 'username',
                        message: 'The password cannot be the same as username'
                    }
                }
            }
        }
    }).on('status.field.bv', function (e, data) {
        var $form = $(e.target),
        validator = data.bv,
        $tabPane = data.element.parents('.tab-pane'),
        tabId = $tabPane.attr('id');

        if (tabId) {
            var $icon = $('a[href="#' + tabId + '"][data-toggle="tab"]').parent().find('i');
            // Add custom class to tab containing the field
            if (data.status == validator.STATUS_INVALID) {
                $icon.removeClass(faIcon.valid).addClass(faIcon.invalid);
            } else if (data.status == validator.STATUS_VALID) {
                var isValidTab = validator.isValidContainer($tabPane);
                $icon.removeClass(faIcon.valid).addClass(isValidTab ? faIcon.valid : faIcon.invalid);
            }
        }
    });

    $('#regForm').bootstrapValidator({
        message: 'This value is not valid',
        excluded: [':disabled'],
        //feedbackIcons: faIcon,
        fields: {
            FullName: {
                container: 'demo-error-container',
                validators: {
                    notEmpty: {
                        message: 'The Fullname is required and cannot be empty'
                    },
                    regexp: {
                        regexp: /^[A-Z\s]+$/i,
                        message: 'The Fullname can only consist of alphabetical characters and spaces'
                    }
                }
            },
            CompanyName: {
                validators: {
                    notEmpty: {
                        message: 'The Company name is required and cannot be empty'
                    }                    
                }
            },
            Email: {
                container: '#demo-error-container',
                message: 'The Email is not valid',
                validators: {
                    notEmpty: {
                        message: 'The Email is required and cannot be empty'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    },
                    //regexp: {
                    //    regexp: /^[a-zA-Z0-9_\.]+$/,
                    //    message: 'The username can only consist of alphabetical, number, dot and underscore'
                    //},
                    different: {
                        field: 'password',
                        message: 'The Email and password cannot be the same as each other'
                    }
                }
            },
            Password: {
                container: '#demo-error-container',
                validators: {
                    notEmpty: {
                        message: 'The password is required and cannot be empty'
                    },
                    stringLength: {
                        min: 6,
                        max: 20,
                        message: 'The password must be more than 6 and less than 20 characters long'
                    },
                    different: {
                        field: 'username',
                        message: 'The password cannot be the same as Email'
                    }
                }
            }
        }
    }).on('status.field.bv', function (e, data) {
        var $form = $(e.target),
        validator = data.bv,
        $tabPane = data.element.parents('.tab-pane'),
        tabId = $tabPane.attr('id');

        if (tabId) {
            var $icon = $('a[href="#' + tabId + '"][data-toggle="tab"]').parent().find('i');
            // Add custom class to tab containing the field
            if (data.status == validator.STATUS_INVALID) {
                $icon.removeClass(faIcon.valid).addClass(faIcon.invalid);
            } else if (data.status == validator.STATUS_VALID) {
                var isValidTab = validator.isValidContainer($tabPane);
                $icon.removeClass(faIcon.valid).addClass(isValidTab ? faIcon.valid : faIcon.invalid);
            }
        }
    });

    $('#fpForm').bootstrapValidator({
        message: 'This value is not valid',
        excluded: [':disabled'],
        //feedbackIcons: faIcon,
        fields: {
            Email: {
                container: '#demo-error-container',
                message: 'The username is not valid',
                validators: {
                    notEmpty: {
                        message: 'The username is required and cannot be empty'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    }                   
                    
                }
            }          
        }
    }).on('status.field.bv', function (e, data) {
        var $form = $(e.target),
        validator = data.bv,
        $tabPane = data.element.parents('.tab-pane'),
        tabId = $tabPane.attr('id');

        if (tabId) {
            var $icon = $('a[href="#' + tabId + '"][data-toggle="tab"]').parent().find('i');
            // Add custom class to tab containing the field
            if (data.status == validator.STATUS_INVALID) {
                $icon.removeClass(faIcon.valid).addClass(faIcon.invalid);
            } else if (data.status == validator.STATUS_VALID) {
                var isValidTab = validator.isValidContainer($tabPane);
                $icon.removeClass(faIcon.valid).addClass(isValidTab ? faIcon.valid : faIcon.invalid);
            }
        }
    });
});



