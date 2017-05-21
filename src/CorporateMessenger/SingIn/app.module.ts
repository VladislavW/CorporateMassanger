import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';





//, RouterModule.forRoot(appRoutes)

@NgModule({
        imports: [BrowserModule, HttpModule, JsonpModule, FormsModule],
        declarations: [AppComponent, LoginComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
