import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'categorieslist',
    templateUrl: './categorieslist.component.html'
})
export class CategoriesListComponent {
    public categories: Category[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/SampleData/GetCategories').subscribe(result => {
            this.categories = result.json() as Category[];

        }, error => console.error(error));
    }

    loadImage() {
        console.log('zzz');
    }

}

interface Category {
    "id": string;
    "name": string;
}
