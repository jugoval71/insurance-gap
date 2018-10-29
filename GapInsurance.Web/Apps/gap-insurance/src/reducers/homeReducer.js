
import * as homeActionConstants from '../constants/home';

function handleGetPolicies(state, action) {
    //Return state
    return {
        ...state, productConfig: {
            ...state.productConfig,
        },
    };
}


const homeReducer = {
    [homeActionConstants.HOME_USER_POLICIES_LOADED]: (state, action) => handleGetPolicies(state, action),
};
export default homeReducer;