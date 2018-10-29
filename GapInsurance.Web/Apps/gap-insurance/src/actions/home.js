import * as HomeActionConstants from '../constants/home';

export const getUserPolicies = (userId) => ({
    type: HomeActionConstants.HOME_USER_POLICIES_REQUEST,
    userId: userId,
}); 
