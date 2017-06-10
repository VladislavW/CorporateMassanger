"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const app_service_1 = require('./app.service');
let AppComponent = class AppComponent {
    constructor(apiService) {
        this.apiService = apiService;
    }
};
AppComponent = __decorate([
    core_1.Component({
        selector: 'app',
        templateUrl: './html/messenger/messenger.html',
        providers: [app_service_1.ApiService]
    }), 
    __metadata('design:paramtypes', [(typeof (_a = typeof app_service_1.ApiService !== 'undefined' && app_service_1.ApiService) === 'function' && _a) || Object])
], AppComponent);
exports.AppComponent = AppComponent;
var _a;
//# sourceMappingURL=app.component.js.map