import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { PostsProvider } from './components/contexts/PostsContext';


ReactDOM.render(
  <React.StrictMode>
    <PostsProvider>
    <App />
    </PostsProvider>
    
  </React.StrictMode>,
  document.getElementById('root')
);
