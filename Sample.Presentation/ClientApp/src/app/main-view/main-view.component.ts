import { Component, OnInit } from '@angular/core';
import { SampleMessageService } from '../sample-message/sample-message.service';
import { SampleMessage } from '../model/sample-message';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.scss']
})
export class MainViewComponent implements OnInit {

  messages: SampleMessage[] = [];

  constructor(private messageService: SampleMessageService) { }

  ngOnInit() {
  }

  loadResponse($event) {
    console.log($event);
  }

}
