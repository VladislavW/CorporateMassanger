/// <reference path="../node_modules/angular2-uuid/index.js" />
/// <reference path="../node_modules/jspdf/dist/jspdf.min.js" />
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: 'SingIn',
            msg: 'AuthUserApp',
            conf: 'ConfirmPass',
            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            '@angular/upgrade': 'npm:@angular/upgrade/bundles/upgrade.umd.js',
            'ts-md5': 'npm:ts-md5',
            '@angular/material': 'npm:@angular/material/material.umd.js',
            // other libraries
            'rxjs': 'npm:rxjs',
            'angular2-uuid': 'npm:angular2-uuid',
            'dragula': 'npm:dragula',
            'contra': 'npm:contra',
            'atoa': 'npm:atoa',
            'ticky': 'npm:ticky',
            'crossvent': 'npm:crossvent/src',
            'custom-event': 'npm:custom-event',

            'ng2-dragula': 'npm:ng2-dragula',

            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.js'

           
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            'angular2-uuid': {
                format: 'cjs',
                main: 'index.js',
                defaultExtension: 'js'
            },
            'ng2-dragula': {
                format: 'cjs',
                main: 'ng2-dragula.js',
                defaultExtension: 'js'
            },
            'dragula': { main: 'dragula.js', defaultExtension: 'js' },
            'contra': { main: 'contra.js', defaultExtension: 'js' },
            'atoa': { main: 'atoa.js', defaultExtension: 'js' },
            'ticky': { main: 'ticky.js', defaultExtension: 'js' },
            'crossvent': { main: 'crossvent.js', defaultExtension: 'js' },
            'custom-event': { main: 'index.js', defaultExtension: 'js' },
            app: {
                main: './main.js',
                defaultExtension: 'js'
            },
            msg: {
                main: './main.js',
                defaultExtension: 'js'
            },
            conf: {
                main: './main.js',
                defaultExtension: 'js'
            },
            rxjs: {
                defaultExtension: 'js'
            },
            'ts-md5': {
                main: '/md5.js'
            }
           
        }
    });
})(this);