import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'hello-ben', // typically in html you use hello-ben but in Typescript/javascript -> HelloBen
  templateUrl: './hello-ben.component.html',
})
export class HelloBenComponent {
  public data: DataModel;
  public something: string;
  public fq: string;

  apiUrl: string;
  httpClient: HttpClient;

  // The 'base_URL' provider here is a sample implementaton
  // by Microsoft. It won't work behind reverse proxy.
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
    this.httpClient = http;
  }

  public getData() {
    // here, we provide our URL.
    this.httpClient.get<DataModel>(this.apiUrl + 'api/helloBen/getme').subscribe(result => {
      this.data = result;
      this.something = '';
      this.fq = '';
    }, error => console.error(error));
  }

  public postData() {
    const url = this.apiUrl + 'api/helloBen/stuff/' + this.something + '/in';
    const httpOptions = { params: { fq: parseInt(this.fq, 10) } };
    this.httpClient.post<DataModel>(url, this.data, httpOptions).subscribe(result => {
      this.data = null;
      console.log(result);
    }, error => console.error(error));
  }
}

interface DataModel {
  key: string;
  hour: number;
  array: Array<string>;
}
