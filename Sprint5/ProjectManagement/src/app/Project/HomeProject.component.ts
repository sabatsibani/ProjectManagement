import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceProjectService } from '../Project/ServiceProject.service';
import { Project } from '../Project/Project';

@Component({
  selector: 'app-homeproject',
  templateUrl: './HomeProject.component.html',
  styleUrls: []
})
export class HomeProjectComponent implements OnInit {

  public projects : Project[] = [];

  constructor(private projectService:ServiceProjectService,private router:Router) {
    }

  ngOnInit() {
    if(!localStorage.getItem('token'))
    {
      this.router.navigate(['Login']);
    }
    this.projectService.getAll().subscribe((data: Project[])=>{
      console.log(data);
      this.projects = data;
    }) 
  }

  onSelected(project :Project)
  {
    this.projectService.updateProjectCollection = project;
    this.router.navigate(['ProjectUpdate']);
  }

}
