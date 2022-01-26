import {Category} from "./Category";
import {User} from "./User";
import {Comment} from "./Comment";

export interface News {
  id: number;
  title: string;
  content: string;
  date: string;
  category: Category;
  user: User;
  articleComment: [Comment];
}


