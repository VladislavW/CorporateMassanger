import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { MsgModule } from './msg.module';

var platform = platformBrowserDynamic();

platform.bootstrapModule(MsgModule);