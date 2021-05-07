import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjectManagement';
  username!: string;

  loggedin() {
    this.username = "Welcome!!! " + localStorage.getItem('token');
    return localStorage.getItem('token');
  }
  onLogout() {
    localStorage.removeItem('token');
  }
}
