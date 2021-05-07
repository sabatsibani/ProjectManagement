import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceUserService } from '../User/ServiceUser.service';
import { User } from '../User/User';

@Component({
  selector: 'app-homeuser',
  templateUrl: './HomeUser.component.html',
  styleUrls: []
})
export class HomeUserComponent implements OnInit {
  public users : User[] = [];

  constructor(private userService:ServiceUserService,private router:Router) {
    }

  ngOnInit() {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
    this.userService.getAll().subscribe((data: User[])=>{
      console.log(data);
      this.users = data;
    })  
  }

  onSelected(users :User)
  {
    this.userService.updateUserCollection = users;
    this.router.navigate(['UserUpdate']);
  }
}
