/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';

    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Areas/Admin/Scripts/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Areas/Admin/Scripts/plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Areas/Admin/Scripts/plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Areas/Admin/Scripts/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/img';
    config.filebrowserFlashUploadUrl = '/Areas/Admin/Scripts/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Areas/Admin/Scripts/plugins/ckfinder/');
};
