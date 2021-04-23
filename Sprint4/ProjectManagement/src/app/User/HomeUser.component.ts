import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homeuser',
  templateUrl: './HomeUser.component.html',
  styleUrls: []
})
export class HomeUserComponent implements OnInit {

  public users = [] as any;

  constructor() {
    this.users = [
      { id: 1, firstname: "Mark", lastname: "Dicosta", email: "mark.dicosta@gmail.com" },
      { id: 2, firstname: "sunny", lastname: "peter", email: "sunny.peter@gmail.com" },
      { id: 3, firstname: "Mike", lastname: "king", email: "mike.king@gmail.com" },
      { id: 4, firstname: "diena", lastname: "leri", email: "diena.leri@gmail.com" }
    ]
  }

  ngOnInit(): void {
  }

  trackByuserCode(users: any): number{
    return users.id;
  }

}
