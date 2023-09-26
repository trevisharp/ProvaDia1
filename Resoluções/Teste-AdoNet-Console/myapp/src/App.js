import logo from './logo.svg';
import './App.css';
import Route from './Route.js'
import Page from './Page.js'

function App() {
  return (
      <div>
          <Route path="/">
              <Page/>
          </Route>
      </div>
  );
}

export default App;
