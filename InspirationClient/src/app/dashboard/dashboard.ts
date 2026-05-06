import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { ReactiveFormsModule, FormControl } from '@angular/forms';
import { GenerateInspirationCommand, GenerateInspirationResponse, InspirationService } from '../api';
import { InputText } from 'primeng/inputtext';
import { Button } from 'primeng/button';
import { Card } from 'primeng/card';
import { ProgressSpinner } from 'primeng/progressspinner';
import { Idea } from '../idea/idea';

@Component({
  selector: 'app-dashboard',
  imports: [ReactiveFormsModule, InputText, Button, Card, ProgressSpinner, Idea],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Dashboard {
  protected readonly topicControl = new FormControl('', { nonNullable: true });
  protected readonly ideas = signal<GenerateInspirationResponse[]>([]);
  protected readonly loading = signal(false);

  private readonly inspirationService = inject(InspirationService);

  generateIdeas(): void {
    const topic = this.topicControl.value.trim();
    if (!topic) return;

    this.loading.set(true);
    const command: GenerateInspirationCommand = { topic };
    this.inspirationService.generateInspiration(command).subscribe({
      next: (response) => {
        this.ideas.set(response);
        this.loading.set(false);
      },
      error: () => this.loading.set(false),
    });
  }
}
