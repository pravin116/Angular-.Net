import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { EnrollmentService } from '../enrollment.service';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  client = new User();
  SearchResult = [];
    constructor(private enrollmentService: EnrollmentService) { }
  ngOnInit() {
  }
  SearchDetail() {
    this.enrollmentService.SearchDetail(this.client).subscribe(
      result => {
        this.SearchResult = result;
      }
    );
  }
}
