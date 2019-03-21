import { Component, OnInit } from '@angular/core';
import { SampleMessageService } from '../sample-message/sample-message.service';
import { SampleMessage } from '../model/sample-message';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: []
})
export class MainViewComponent implements OnInit {

  messages: string[] = [];
  // Starter error message
  error: any = 'No data has been loaded.';

  constructor(private messageService: SampleMessageService) { }

  ngOnInit() {
  }

  loadResponse($event) {
    this.messages = [];
    this.error = null;
    this.messageService.getMessages().subscribe(
      value => {
        if (value.length > 0) {
          // Since we want the page to display Hello World 10x per the spec,
          // we need to duplicate that message.
          let firstMessage = value[0];
          for (var i = 0; i < 10; i++) {
            this.messages.push(firstMessage.text);
          }
          this.error = null;
        }
      },
      error => {
        this.error = error;
      }
    );
  }

}
