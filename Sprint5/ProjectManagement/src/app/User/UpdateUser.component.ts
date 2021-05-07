import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceUserService } from '../User/ServiceUser.service';
import { User } from '../User/User'

@Component({
  selector: 'app-updateuser',
  templateUrl: './UpdateUser.component.html',
  styleUrls: []
})
export class UpdateUserComponent implements OnInit {
  constructor(public userService:ServiceUserService,private router:Router) {
  }

  ngOnInit(): void {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
  }

  onUserDelete(id : number)
  {
    this.userService.delete(id).subscribe(res=>
      {
        console.log('User deleted!');
        this.router.navigate(['User']);
    });    
  }

  onUserUpdate()
  {
    this.userService.update(this.userService.updateUserCollection).subscribe(res=>
      {
        console.log('User updated!');
        this.router.navigate(['User']);
    });
  }
}
