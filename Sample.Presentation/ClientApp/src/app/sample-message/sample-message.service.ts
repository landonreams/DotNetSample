import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SampleMessage } from '../model/sample-message';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SampleMessageService {
  private messageUrl = 'api/messages';
  private messages: SampleMessage[];

  constructor(private http: HttpClient) { }

  getMessages(): Observable<SampleMessage[]> {
    return this.http.get<SampleMessage[]>(this.messageUrl);
  }
}
