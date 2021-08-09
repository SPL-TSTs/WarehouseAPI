import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
export type DeviceType = 'watermeter' | 'electricmeter' | 'gateway';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  device: DeviceType = 'watermeter';
  public devices: Device[];

  constructor(private http: HttpClient) {}
  

  get showWaterResult() {
    return this.device === 'watermeter';
  }

  get showElectricResult() {
    return this.device === 'electricmeter';
  }

  get showGatewayResult() {
    return this.device === 'gateway';
  }

  toggleEditor(type: DeviceType) {
    this.device = type;
    const url = 'https://localhost:44354/';
    const httpOptions = {
      headers: new HttpHeaders({
        'Accept': '*/*'
      })
    };
    this.http.get<Device[]>(url+type, httpOptions).subscribe(result => {
        this.devices = result;
      },
      error => console.error(error));
  }

}

interface Device {
  id: string;
  serialNumber: string;
  firmwareVersion: string;
  state: string;
  ip: string;
  port: number;
}
