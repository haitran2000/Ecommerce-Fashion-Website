import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BlogService } from './blog.service';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.scss']
})
export class BlogsComponent implements OnInit {

  constructor(
    public service:BlogService,
    public router : Router,
    public http: HttpClient,
    public dialog: MatDialog,
    public toastr: ToastrService,
            ) { }

  ngOnInit(): void {
  }
  
}
