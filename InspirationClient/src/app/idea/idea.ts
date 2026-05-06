import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { GenerateInspirationResponse } from '../api';
import { Card } from 'primeng/card';

@Component({
  selector: 'app-idea',
  imports: [Card],
  templateUrl: './idea.html',
  styleUrl: './idea.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Idea {
  inspirationIdea = input.required<GenerateInspirationResponse>();
}
