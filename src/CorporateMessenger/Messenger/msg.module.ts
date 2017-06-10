import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MsgComponent } from './msg.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';





//, RouterModule.forRoot(appRoutes)

@NgModule({
        imports: [BrowserModule, HttpModule, JsonpModule, FormsModule],
        declarations: [MsgComponent],
        bootstrap: [MsgComponent]
})
export class MsgModule { }
