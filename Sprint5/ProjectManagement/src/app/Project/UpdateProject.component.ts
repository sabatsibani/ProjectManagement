import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceProjectService } from '../Project/ServiceProject.service';
import { Project } from '../Project/Project'

@Component({
  selector: 'app-updateproject',
  templateUrl: './UpdateProject.component.html',
  styleUrls: []
})
export class UpdateProjectComponent implements OnInit {

  constructor(public serviceProject: ServiceProjectService,private router:Router) { }

  ngOnInit(): void {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
  }
  onProjectDelete(id: number) {
    this.serviceProject.delete(id).subscribe(res => {
      console.log('Project deleted!');
      this.router.navigate(['Project']);
    });
  }

  onProjectUpdate() {
    this.serviceProject.update(this.serviceProject.updateProjectCollection).subscribe(res => {
      console.log('Project updated!');
      this.router.navigate(['Project']);
    });
  }
}