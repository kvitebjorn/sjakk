import { render, screen } from '@testing-library/react';
import App from '../src/App';

test('renders sjakk title', () => {
  render(<App />);
  const linkElement = screen.getByText(/sjakk/i);
  expect(linkElement).toBeInTheDocument();
});
