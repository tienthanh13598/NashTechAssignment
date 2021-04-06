import './App.css';
import BillingPlan from './components/billing-plan';
import Statistic from './components/statistic';

function App() {
  let plans = [{
    logo: "shopping-cart",
    name: "Basic",
    price: 100,
    privilege: [
      { name: '01 Seat', included: true },
      { name: 'Tea & Coffee Breaks', included: false },
      { name: 'Wifi Available', included: false },
      { name: 'Exclusive Seatings', included: false }
  ]}, {
    logo: "car",
    name: "Standard",
    price: 200,
    privilege: [
      { name: '02 Seat', included: true },
      { name: 'Tea & Coffee Breaks', included: true },
      { name: 'Wifi Available', included: false },
      { name: 'Exclusive Seatings', included: false }
  ]}, {
    logo: "rocket",
    name: "Premium",
    price: 300,
    privilege: [
      { name: '04 Seat', included: true },
      { name: 'Tea & Coffee Breaks', included: true },
      { name: 'Wifi Available', included: true },
      { name: 'Exclusive Seatings', included: true }
    ]
  }];

  let statistics = [{
    icon: 'microphone',
    amount: '36+',
    descripiton: 'Unique Sessions'
  }, {
    icon: 'user-friends',
    amount: '12',
    descripiton: 'Amazing Speakers'
  }, {
    icon: 'mug-hot',
    amount: '45',
    descripiton: 'Food Stalls'
  }, {
    icon: 'book',
    amount: '2350+',
    descripiton: 'Books Available'
  }]

  return (
    <>
      <div className="container mt-5">
        <div className="row">
          {plans.map(p => 
            <BillingPlan {...p} />
          )}
        </div>
      </div>
      <div className="container mt-5">
        <div className="row" style={{background: '#e3f7f8', borderRadius: '50px'}}>
          {statistics.map(s => 
            <Statistic {...s} />
          )}
        </div>
      </div>
    </>
  );
}

export default App;