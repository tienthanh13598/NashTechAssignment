import '../css/statistic.css';

interface StatisticProps {
    icon: string,
    amount: string,
    descripiton: string
}

export const Statistic = ({...props}: StatisticProps) => {
    return <div className="row col-md-3">
        <div className="Statistic-icon col-md-4 align-self-center">
            <span className="float-right"><i className={`fa fa-${props.icon}`} /></span>
        </div>
        <div className="Statistic-text col-md-8">
            <p className="my-0">{props.amount}</p>
            <p>{props.descripiton}</p>
        </div>
    </div>
};

export default Statistic;