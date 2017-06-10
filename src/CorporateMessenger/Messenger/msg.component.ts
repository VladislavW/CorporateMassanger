import { Component } from '@angular/core';
import { MsgService } from './msg.service';

@Component({
    selector: 'app',
    templateUrl: './html/messenger/messenger.html',
    providers: [MsgService]
})
export class MsgComponent {


    constructor(private msgService: MsgService) {

    }

}
