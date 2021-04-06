import '../css/billing-plan.css';

interface Privilege {
    name: string,
    included: boolean
}

interface BillingPlanProps {
    logo: string,
    name: string,
    price: number,
    privilege: Privilege[]
}

export const BillingPlan = ({...props}: BillingPlanProps) => {
    return <div className="Billing-card card col-md-3 mx-4 text-center">
        <div className="Billing-header mt-4">
            <i className={`fa fa-${props.logo}`} />
            <p>{props.name}</p>
        </div>
        <div className="Billing-body align-self-center">
            <h1>${props.price}</h1>
            <p>including all taxes</p>
            <div className="mt-4 text-left">
                {props.privilege.map(p =>
                    <div className={p.included ? 'Privilege-included': 'Privilege-excluded'}>
                        <i className={`fas fa-${p.included ? 'check': 'times'}`}></i>
                        <span className="px-2">{p.name}</span>
                    </div>
                )}
            </div>
        </div>
        <div className="Billing-footer my-4">
            <button className="btn btn-primary py-1 px-5">
                <i className="fas fa-ticket-alt"></i>
                <span className="mx-2">Buy now</span>
            </button>
        </div>
    </div>
}

export default BillingPlan;