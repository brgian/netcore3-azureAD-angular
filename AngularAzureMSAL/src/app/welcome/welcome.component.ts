import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { TestService } from '../test.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  public idToken: string;

  constructor(private msalService: MsalService, private testService: TestService) { }

  ngOnInit() {
  }

  logOut(){
    this.msalService.logout();
  }

  testAuth(){
    this.testService.getReservationsFilteredCount().subscribe(x => {alert('Backend authentication success!')},
      errorResponse => alert(errorResponse));
  }
}
