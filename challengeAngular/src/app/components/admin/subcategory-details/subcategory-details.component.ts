import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subcategory',
  template: `<div class="modal-content">
  <div class="modal-header">
    <h4 style="text-align: left">Subcategory</h4>
    <button type="button" class="close" data-dismiss="modal"> &times;</button>
  </div>
  <div class="modal-body">

  </div>
</div>`
})

export class SubcategoryDetailsComponent implements OnInit {
  constructor() { }

  ngOnInit() { }

  addSubcategory() {}

}
