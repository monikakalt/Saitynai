import { Pipe, PipeTransform } from '@angular/core';
import { Observable } from 'rxjs/';

@Pipe({
  name: 'challengeFilter'
})

export class ChallengeCategoriesFilterPipe implements PipeTransform {
  transform(items: Observable<any>, subcategoryTypeFilter: string): any {
    console.log(subcategoryTypeFilter);
    if (items == null) {
      return [];
      
    }
    var cat = parseInt(subcategoryTypeFilter.substring(0, 1));
    var sub = parseInt(subcategoryTypeFilter.substring(1, subcategoryTypeFilter.length));

    if (cat && sub) {
      return items.filter(i => i.subcategory === sub && i.category === cat);
    }
    else if (sub)
    {
      return items.filter(i => i.subcategory === sub);
    }
    else if (cat)
    {
      return items.filter(i => i.category === cat);
    }

    return items;
  }
}
